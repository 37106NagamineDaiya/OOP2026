using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDi {
    public interface ITextFileService {
        void Initialize(string fname);
        bool Execute(string line);
        void Terminate();
    }
}
