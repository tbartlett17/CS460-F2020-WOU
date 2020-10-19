using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS460_HW3
{
    class Program
    {
        private static void PrintUsage()
        {
            Console.WriteLine("usage is: \n" +
                "\tjava C inputfile \n\n" +
            "Where:" +
            "  C is the column number to fit to\n" +
            "  inputfile is the input text file \n" +
            "  e.g. java 72 myfile.txt");
        }


        /*
        -------------------------------------------------------------------------
		    Greedy Algorithm (Non-optimal i.e. approximate or heuristic solution)
	    -------------------------------------------------------------------------

            As an example only, write out the file directly to the output with _simple_ wrapping,
            i.e. adding spaces between words and moving to the next line if a word would go past the
            indicated column number C.  This will fail if any word length exceeds the column limit C,
            but it still goes ahead and just puts one word on that line.
        */
        private static int WrapSimply(IQueueInterface<string> words, int columnLength, string outputFileName)
        {
            StreamWriter writer;

            try
            {
                writer = new StreamWriter(outputFileName);
                writer.AutoFlush = true;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot create or open " + outputFileName +
                        " for writing.  Using standard output instead.");
                writer = new StreamWriter(Console.OpenStandardOutput());
            }

            int col = 1;
            int spacesRemaining = 0;			// Running count of spaces left at the end of lines

            while (!words.IsEmpty())
            {
                string str = words.Peek();
                int len = str.Length;

                //Console.WriteLine(col+len);
                // See if we need to wrap to the next line
                if (col == 1)
                {
                    writer.Write(str);
                    col += len;
                    words.Pop();
                }
                else if ((col + len) >= columnLength)
                {// go to the next line
                    writer.WriteLine();
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {// Typical case of printing the next word on the same line
                    //writer.Write(" ");
                    writer.Write(" " + str);
                    col += (len + 1);
                    words.Pop();
                }
            }

            writer.WriteLine();
            writer.Flush();
            writer.Close();

            return spacesRemaining;
        }


        static void Main(string[] args)
        {
            int C = 72; //Column Length to wrap to
            string inputFileName = "";
            string outputFileName = "";
            string[] fileContents;
            
            if (args.Length != 2)
            {
                PrintUsage();
                Environment.Exit(1);
            }
            try
            {
                C = Int32.Parse(args[0]);
                inputFileName = args[1];
                outputFileName = inputFileName.Remove((inputFileName.Length - 4)) 
                    + "_wrapped_at_" + C + ".txt";
                
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Could not find the input file.");
                Environment.Exit(1);
            }
            catch (Exception)
            {
                Console.WriteLine("Something is wrong with the input.");
                PrintUsage();
                Environment.Exit(1);
            }

            // Read words and their lengths into these vectors
            IQueueInterface<string> words = new LinkedQueue<string>();

            StreamReader reader = new StreamReader(inputFileName);

            char[] delimeters = { ' ', '\n', '\r' };

            //Read file into string[] split by whitespace
            fileContents = reader.ReadToEnd().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

            //Split each word into array of strings
            //string[] text = fileContents.Split(' ');

            //turn each word into a node
            for (int i = 0; i < fileContents.Length; i++)
            {
                string word = fileContents[i];
                words.Push(word);
            }
            reader.Close();

            // At this point the input text file has now been placed, word by word, into a FIFO queue
            // Each word does not have whitespaces included, but does have punctuation, numbers, etc.

            int spacesRemaining = WrapSimply(words, C, outputFileName);
            Console.WriteLine("\nTotal spaces remaining (Greedy): " + spacesRemaining);


            //Console.WriteLine(fileContents)
            //StreamWriter writer = new StreamWriter(outputFileName);
            //writer.WriteLine(fileContents);

            
        }
    }
}
