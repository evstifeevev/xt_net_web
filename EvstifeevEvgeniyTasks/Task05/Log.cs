using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task05
{
    public class Log
    {
        public WatcherChangeTypes changeType = default;
        public DateTime logdate { get; } = default;
        public string fileFullName { get; } = default;
        public string fileOldName { get; } = default;
        public List<string> _fileChanges { get; } = new List<string>();
        public List<int> _fileChangePosition { get; } = new List<int>();
        public Log(DateTime logDate, string fileFullName, string fileOldName, WatcherChangeTypes changeType)
        {
            this.logdate = logDate;
            this.fileFullName = fileFullName;
            this.fileOldName = fileOldName;
            this.changeType = changeType;

        }
        public void AddAllLines(List<string> lines)
        {
            _fileChanges.AddRange(lines);
            for (int i = 0; i < lines.Count; i++)
            {
                _fileChangePosition.Add(i);
            }
        }
        public void AddChangedLine(int position, string changedLine)
        {
            _fileChanges.Add(changedLine);
            _fileChangePosition.Add(position);
        }
        public void RemoveLine(int position, string removableLine)
        {
            for (int i = _fileChanges.Count; i >= 0; i--)
            {
                if (_fileChanges[i] == removableLine)
                {
                    _fileChanges.RemoveAt(i);
                    _fileChangePosition.RemoveAt(i);
                    break;
                }
            }


        }
    }
}
