import axios from 'axios';

// Lấy URL backend từ biến môi trường
const baseURL = import.meta.env.VITE_BACKEND_URL;

// Tạo instance axios với cấu hình cơ bản
const instance = axios.create({
  baseURL: baseURL,
  // withCredentials: false, // Để gửi cookies theo yêu cầu
});

// Thiết lập header Authorization mặc định nếu có token
const setAuthorizationHeader = () => {
  const token = localStorage.getItem('access_token');
  if (token) {
    instance.defaults.headers.common['Authorization'] = `Bearer ${token}`;
  }
};

// Gọi hàm thiết lập header khi khởi tạo instance
setAuthorizationHeader();

// Hàm xử lý refresh token
const handleRefreshToken = async () => {
  try {
    const response = await instance.get('/api/v1/auth/refresh');
    if (response && response.data) {
      return response.data.access_token;
    }
    return null;
  } catch (error) {
    console.error('Refresh token failed:', error);
    return null;
  }
};

// Header để tránh vòng lặp khi retry
const NO_RETRY_HEADER = 'x-no-retry';

// Thêm interceptor request để thêm header Authorization nếu có
instance.interceptors.request.use(
  config => {
    setAuthorizationHeader(); // Đảm bảo header Authorization được thiết lập
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

// Thêm interceptor response để xử lý token refresh và lỗi
instance.interceptors.response.use(
  response => {
    return response || "undefined";
  },
  async error => {
    const { config, response } = error;

    // Xử lý khi nhận được lỗi 401 (Unauthorized)
    if (response && response.status === 401 && !config.headers[NO_RETRY_HEADER]) {
      // Thử refresh token
      const newAccessToken = await handleRefreshToken();
      if (newAccessToken) {
        config.headers[NO_RETRY_HEADER] = 'true'; // Đánh dấu là đã retry
        localStorage.setItem('access_token', newAccessToken); // Lưu token mới
        instance.defaults.headers.common['Authorization'] = `Bearer ${newAccessToken}`; // Cập nhật header

        // Thực hiện lại request với token mới
        return instance.request(config);
      }
    }

    // Nếu lỗi 400 khi refresh token, điều hướng đến trang đăng nhập
    if (response && response.status === 400 && config.url === '/api/v1/auth/refresh') {
      window.location.href = '/login';
    }

    return Promise.reject(error.response?.data || error);
  }
);

export default instance;
