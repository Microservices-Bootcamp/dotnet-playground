using System;
namespace src
{
    public interface CustomMiddleware
    {
        public void SetNext(CustomMiddleware next);
        public void Handle();
    }

    public class MiddleWare1 : CustomMiddleware
    {
        private CustomMiddleware _next;

        public void SetNext(CustomMiddleware next)
        {
            _next = next;
        }

        public void Handle()
        {
            Console.WriteLine("Before Handle Middleware1");
            if (_next != null)
                _next.Handle();
            Console.WriteLine("After Handle Middleware1");
        }
    }

    public class MiddleWare2 : CustomMiddleware
    {
        private CustomMiddleware _next;

        public void SetNext(CustomMiddleware next)
        {
            _next = next;
        }

        public void Handle()
        {
            Console.WriteLine("Before Handle Middleware2");
            if (_next != null)
                _next.Handle();
            Console.WriteLine("After Handle Middleware2");
        }
    }
}

