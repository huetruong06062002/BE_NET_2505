namespace BE_2505_NetCoreAPI
{
    public class MyCustomMiddleWare
    {
        private RequestDelegate _next;


        public MyCustomMiddleWare(RequestDelegate next)
        {
            _next = next;
        }


        public Task Invoke(HttpContext context)
        {
            //return context.Response.WriteAsync("Hello from custom middleware");
            return _next(context);
        }
    }
}
