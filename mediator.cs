using System;

namespace main
{
    public interface Mediator
    {
        void Notify(object sender, string ev);
    }

    class AuthenticationDialog : Mediator
    {
        private Button _button;
        private Textbox _textbox;
        private Checkbox _checkbox;

        public AuthenticationDialog(Button button, Textbox textbox, Checkbox checkbox)
        {
            this._button = button;
            this._button.SetMediator(this);
            this._textbox = textbox;
            this._textbox.SetMediator(this);
            this._checkbox = checkbox;
            this._checkbox.SetMediator(this);
        } 

        public void Notify(object sender, string ev)
        {
            if (ev == "click")
            {
                Console.WriteLine("Button was clicked on.");
            }
            if (ev == "keypress")
            {
                Console.WriteLine("Text was entered.");
            }
            if (ev == "check")
            {
                Console.WriteLine("Checkbox was checked.");
            }
        }
    }

    class Component
    {
        protected Mediator _mediator;

        public Component(Mediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(Mediator mediator)
        {
            this._mediator = mediator;
        }
    }

    class Button : Component
    {
        public void Click()
        {
            this._mediator.Notify(this, "click");
        }
    }

    class Textbox : Component
    {
        public void KeyPress()
        {
            this._mediator.Notify(this, "keypress");
        }
    }
    
    class Checkbox : Component
    {
        public void Check()
        {
            this._mediator.Notify(this, "check");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Button button = new Button();
            Textbox textbox = new Textbox();
            Checkbox checkbox = new Checkbox();
            new  AuthenticationDialog(button, textbox, checkbox);

            Console.WriteLine("Client clicks a button.");
            button.Click();

            Console.WriteLine("Client enters text.");
            textbox.KeyPress();
            
            Console.WriteLine("Client checks a box.");
            checkbox.Check();
        }
    }
}
