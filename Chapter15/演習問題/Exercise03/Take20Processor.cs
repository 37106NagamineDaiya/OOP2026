using System;
using TextFileProcessorDi;

namespace Exercise03 {
    internal class Take20Processor : ITextFileService {
        private int count = 0;

        public void Initialize(string fname) {
            count = 0;
        }

        public bool Execute(string line) {

            Console.WriteLine(line);

            count++;

            return count < 20;
        }

        void ITextFileService.Terminate() {

        }
    }
}