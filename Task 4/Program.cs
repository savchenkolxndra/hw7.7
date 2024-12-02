using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasSpruce spruce = new ChristmasSpruce();
            ChristmasPine pine = new ChristmasPine();
            OrnamentDecorator d1 = new OrnamentDecorator();
            GarlandDecorator d2 = new GarlandDecorator();

            // Link decorators
            d1.SetComponent(spruce);
            d2.SetComponent(d1);

            d2.DecorateRoom();

            d2.Glow();

            d1.SetComponent(pine);
            d2.SetComponent(d1);

            d2.DecorateRoom();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class ChristmasTree
    {
        public abstract void DecorateRoom();
    }

    // "ConcreteComponent"
    class ChristmasSpruce : ChristmasTree
    {
        public override void DecorateRoom()
        {
            Console.Write("A Christmas spruce decorates the room");
        }
    }

    class ChristmasPine : ChristmasTree
    {
        public override void DecorateRoom()
        {
            Console.Write("A Christmas pine decorates the room");
        }
    } 

    // "Decorator"
    abstract class Decorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public void SetComponent(ChristmasTree tree)
        {
            this.tree = tree;
        }
        public override void DecorateRoom()
        {
            if (tree != null)
            {
                tree.DecorateRoom();
            }
        }
    }

    // "ConcreteDecoratorA"
    class OrnamentDecorator : Decorator
    {
        private string addedState;

        public override void DecorateRoom()
        {
            base.DecorateRoom();
            addedState = " with the blue balls";
            Console.Write(addedState);
        }
    }

    // "ConcreteDecoratorB" 
    class GarlandDecorator : Decorator
    {
        public override void DecorateRoom()
        {
            base.DecorateRoom();
            Console.WriteLine(" and with the garlands");
        }

        public void Glow()
        {
            Console.WriteLine("The garlands glow!");
        }
    }
}