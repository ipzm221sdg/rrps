using System;
using System.Collections.Generic;

namespace main
{
    public interface Handler
    {
        Handler SetNext(Handler handler);
        
        object Handle(object request);
    }

    abstract class BaseHandler : Handler
    {
        private Handler _nextHandler;

        public Handler SetNext(Handler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        
        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }

    class InvalidLoginHandler : BaseHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Invalid login")
            {
                return "Your login is invalid. Try again.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class InvalidPasswordHandler : BaseHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "Invalid password")
            {
                return "Your password is invalid. Try again.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class ValidLoginAndPasswordHandler : BaseHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "Valid login and password")
            {
                return "You have succesfully loged in.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var invalidLogin = new InvalidLoginHandler();
            var invalidPassword = new InvalidPasswordHandler();
            var validLoginPass = new ValidLoginAndPasswordHandler();
            
            List<string> list = new List<string> { "Invalid login", "Invalid password", "Valid login and password" };

            invalidLogin.SetNext(invalidPassword).SetNext(validLoginPass);

            Console.WriteLine("Chain: Invalid login > invalid password > valid login and password\n");
            
            foreach (var crd in list)
            {
                Console.WriteLine($"Client enters {crd}.\n");

                var result = invalidLogin.Handle(crd);

                if (result != null)
                {
                    Console.Write($"   {result}");
                }
            }
            Console.WriteLine();
        }
    }
}