using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace C_17_Form
{
    public class To_File_Time: TimeoutException
    {
        TimeoutException ex;

        public void Report()
        {
            MessageBox.Show("Ooops!","Problem with null reference" + ex.Message);
        }
    }

    public class To_File_Unauthorized : UnauthorizedAccessException
    {
        UnauthorizedAccessException ex;

        public void Report()
        {
            MessageBox.Show("Ooops!", "Problem with null reference" + ex.Message);
        }
    }

    public class To_File_Exeption : Exception
    {
        Exception ex;

        public void Report()
        {
            MessageBox.Show("Ooops!", "Problem with null reference" + ex.Message);
        }
    }

    public class From_File: UnauthorizedAccessException
    {
        UnauthorizedAccessException ex;

        public void Report()
        {
            MessageBox.Show("Ooops!", "Problem with null reference" + ex.Message);
        }
    }

    public class From_File_InvalidCast: InvalidCastException
    {
        InvalidCastException ex;

        public void Report()
        {
            MessageBox.Show("Ooops!", "Problem with null reference" + ex.Message);
        }
    }

    public class From_FileNotFound: SystemException
    {
        SystemException ex;

        public void Report()
        {
            MessageBox.Show("Ooops!", "Problem with null reference" + ex.Message);
        }
    }
}
