// 反射

/*
优点：
1、反射提高了程序的灵活性和扩展性。
2、降低耦合性，提高自适应能力。
3、它允许程序创建和控制任何类的对象，无需提前硬编码目标类
缺点：
1、性能问题：使用反射基本上是一种解释操作，用于字段和方法接入时要远慢于直接代码。因此反射机制主要应用在对灵活性和拓展性要求很高的系统框架上，普通程序不建议使用。
2、使用反射会模糊程序内部逻辑；程序员希望在源代码中看到程序的逻辑，反射却绕过了源代码的技术，因而会带来维护的问题，反射代码比相应的直接代码更复杂。
 用途：
它允许在运行时查看特性（attribute）信息。
它允许审查集合中的各种类型，以及实例化这些类型。
它允许延迟绑定的方法和属性（property）。
它允许在运行时创建新类型，然后使用这些类型执行一些任务
 */
 using System;
using System.Reflection;

//查看元数据实例
[AttributeUsage(AttributeTargets.All)]
public class HelpAttribute : System.Attribute
{
    public readonly string url;

    public string Topic
    {
        get
        {
            return Topic;
        }
        set
        {
            topic = value;
        }
    }

    public HelpAttribute(string url)
    {
        this.url = url;
    }

    private string topic;
}

[HelpAttribute("Information on the class MyCalss")]
class MyClass
{
    
}

namespace AttributeApp1
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     System.Reflection.MemberInfo info = typeof(MyClass);
        //     object[] attributes = info.GetCustomAttributes(true);
        //     for (int i = 0; i < attributes.Length; i++)
        //     {
        //         System.Console.WriteLine(attributes[i]);
        //     }
        //
        //     Console.ReadKey();
        // }
    }
}

namespace BugfixApplication
{
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Constructor |
                    AttributeTargets.Field |
                    AttributeTargets.Method |
                    AttributeTargets.Property,
        AllowMultiple = true)]

    public class DeBugInfo : System.Attribute
    {
        private int bugNo;
        private string developer;
        private string lastReview;
        public string message;

        public DeBugInfo(int bg, string dev, string d)
        {
            this.bugNo = bg;
            this.developer = dev;
            this.lastReview = d;
        }

        public int BugNo
        {
            get
            {
                return bugNo;
            }
        }

        public string Devloper
        {
            get
            {
                return developer;
            }
        }

        public string LastReview
        {
            get
            {
                return lastReview;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
    }

    [DeBugInfo(45, "Zara Ali", "12/8/2012",
        Message = "Return type mismatch")]
    [DeBugInfo(49, "Nuha Ali", "10/10/2012",
        Message = "Unused variable")]

    class Rectangle
    {
        protected double length;
        protected double width;

        public Rectangle(double a, double w)
        {
            length = a;
            width = w;
        }

        [DeBugInfo(55, "Zara Ali", "20/11/2022", Message = "Return type mismatch")]
        
        public double GetArea()
        {
            return length * width;
        }

        [DeBugInfo(56, "Zara Ali", "19/10/2012")]

        public void Display()
        {
            Console.WriteLine("Length：{0}",length);
            Console.WriteLine("Width：{0}",width);
            Console.WriteLine("Area：{0}",GetArea());
        }

        class ExecuteRectangle
        {
            // static void Main(string[] args)
            // {
            //     Rectangle r = new Rectangle(4.5, 7.5);
            //     r.Display();
            //     Type type = typeof(Rectangle);
            //     foreach (Object attributes in type.GetCustomAttributes(false))
            //     {
            //         DeBugInfo dbi = (DeBugInfo) attributes;
            //         if (null != dbi)
            //         {
            //             Console.WriteLine("Bug no：{0}", dbi.BugNo);
            //             Console.WriteLine("Developer：{0}", dbi.Devloper);
            //             Console.WriteLine("Last Reviewed：{0}", dbi.LastReview);
            //             Console.WriteLine("Remarks：{0}", dbi.Message);
            //         }
            //     }
            //
            //     foreach (MethodInfo m in type.GetMethods())
            //     {
            //         foreach (Attribute a in m.GetCustomAttributes(false))
            //         {
            //             DeBugInfo dbi = (DeBugInfo) a;
            //             if (null != dbi)
            //             {
            //                 Console.WriteLine("Bug no：{0}，for Method：{1}",dbi.BugNo,m.Name);
            //                 Console.WriteLine("Developer：{0}",dbi.Devloper);
            //                 Console.WriteLine("Last Reviewed：{0}",dbi.LastReview);
            //                 Console.WriteLine("Remarks：{0}",dbi.Message);
            //             }
            //         }
            //     }
            //
            //     Console.ReadKey();
            // }
        }
    }
}