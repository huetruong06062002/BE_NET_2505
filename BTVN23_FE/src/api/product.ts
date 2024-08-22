import axiosInstance from '../utils/axiosCustom'
const getProducts = () => {
  return axiosInstance.get("/api/Products");
}

export {getProducts};