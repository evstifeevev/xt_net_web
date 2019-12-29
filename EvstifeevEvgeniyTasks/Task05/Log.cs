using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task05
{
    internal class Log
    {
        internal WatcherChangeTypes changeType = default;
        public Log(DateTime logDate, string fileFullName, string fileOldName, WatcherChangeTypes changeType)
        {
            this.logdate = logDate;
            this.fileFullName = fileFullName;
            this.fileOldName = fileOldName;
            this.changeType = changeType;

        }
        internal DateTime logdate { get; } = default;
        internal string fileFullName { get; } = default;
        internal string fileOldName { get; } = default;
        internal List<string> _fileChanges { get; } = new List<string>();
        internal List<int> _fileChangePosition { get; } = new List<int>();

        internal void AddAllLines(List<string> lines)
        {
            _fileChanges.AddRange(lines);
            for (int i = 0; i < lines.Count; i++)
            {
                _fileChangePosition.Add(i);
            }
        }
        internal void AddChangedLine(int position, string changedLine)
        {
            _fileChanges.Add(changedLine);
            _fileChangePosition.Add(position);
        }
        internal void RemoveLine(int position, string removableLine)
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
