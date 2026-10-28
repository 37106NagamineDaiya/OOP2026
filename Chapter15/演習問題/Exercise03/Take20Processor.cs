using System;
using TextFileProcessorDi;

namespace Exercise03 {
    internal class Take20Processor : ITextFileService {
        private int count = 0;

        void ITextFileService.Initialize(string fname) {
            count = 0;
        }

        void ITextFileService.Execute(string line) {
            if (count < 20) {
                Console.WriteLine(line);
                count++;
            }
        }

        void ITextFileService.Terminate() {

        }
    }
}