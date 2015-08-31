using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//添加名称空间
using com_io_ctl;

namespace cicTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                com_io_ctl.com_io_ctl cic = new com_io_ctl.com_io_ctl(System.Environment.CurrentDirectory + "\\io.ini");

                //打开串口
                cic.OpenCom("COM10");

                for (int i = 0; i < 10; i++)
                {
                    //操作开关
                    //0对应#1双工器
                    //1对应#2双工器
                    //...
                    //7对应#8双工器
                    bool result = cic.BaseStateWrite( i );

                    Console.WriteLine("# " + i.ToString() + (result ? " Success!" : " failed!"));
                }

                //释放资源
                cic.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
