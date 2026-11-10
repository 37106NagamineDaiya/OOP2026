using Exercise03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDi {
    public class TextFileProcessor {
        private ITextFileService _service;

        public TextFileProcessor(ITextFileService service) {
            _service = service;
        }

        public void Run(string fileName) {
            _service.Initialize(fileName);
            var lines = File.ReadLines(fileName);
            foreach(var line in lines) {
                
                if (!_service.Execute(line)) {
                    break;
                }

            }
            _service.Terminate();
        }
    }
}
