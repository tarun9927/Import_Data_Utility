using System;
using System.IO;

namespace Fracton.mxCell.ExceptionHandler
{
    public class CustomException : Exception
    {
        private string _TicketNo;

        public CustomException()
        {
            dumpCustomException(base.Message, base.StackTrace, base.Source, "");
        }

        public CustomException(Exception ex)
        {
            dumpCustomException(ex.Message, ex.StackTrace, ex.Source, "");
        }

        public CustomException(Exception ex, string tag)
        {
            dumpCustomException(ex.Message, ex.StackTrace, ex.Source, tag);
        }

        public string TicketNumber
        {
            get { return _TicketNo; }
        }

        public override string Message
        {
            get { return _TicketNo + ": " + "An Error Occurred while Processing your Request."; }
        }

        private void dumpCustomException(string message, string StackTrace, string Source, string tag)
        {
            if (!Directory.Exists(@"C:\MaxCell"))
                Directory.CreateDirectory(@"C:\MaxCell");

            var sw = new StreamWriter(@"C:\MaxCell\Error " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);
            sw.WriteLine("Source Name=" + Source + "       Tag Name=" + tag);
            sw.WriteLine(message);
            sw.WriteLine(StackTrace);
            sw.WriteLine("------------------------------------------------------");
            sw.Flush();
            sw.Close();
        }
    }
}
