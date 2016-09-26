using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ConsoleRedirection
{
    public class TextBoxStreamWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxStreamWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            //_output.Invoke(new Action(() => _output.Text = _output.Text + value));
            _output.Invoke(new Action(() => _output.AppendText(value.ToString())));
            //base.Write(value);
            //_output.AppendText(value.ToString()); // When character data is written, append it to the text box.
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}