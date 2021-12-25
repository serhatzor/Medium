using System.Text;

namespace WeakReferenceExample
{
    public class WeakReferenceItem
    {
        public DateTime CreateDate { get; private set; } = DateTime.UtcNow;
        public DateTime? DoneDate { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public WeakReference Reference { get; set; }
        public bool HasSuspectedMemoryLeak { get; set; }
    }
    public static class MemorLeakTracer
    {
        private static Dictionary<int, WeakReferenceItem> _references = new Dictionary<int, WeakReferenceItem>();

        public static void AddObject(object value)
        {
            if (value == null)
                return;

            _references.Add(value.GetHashCode(), new WeakReferenceItem()
            {
                Reference = new WeakReference(value),
                TypeName = value.GetType().Name
            });
        }

        public static void SetAsDone(object value)
        {
            WeakReferenceItem item = _references[value.GetHashCode()];
            item.DoneDate = DateTime.UtcNow;
        }

        public static string FindSuspectedMemoryLeaks()
        {
            GC.Collect();

            StringBuilder logs = new StringBuilder();

            bool findAtLeastOne = false;
            foreach (WeakReferenceItem weakReferenceItem in _references.Values)
            {
                if (weakReferenceItem.DoneDate != DateTime.MinValue && weakReferenceItem.Reference.IsAlive)
                {
                    weakReferenceItem.HasSuspectedMemoryLeak = true;
                    logs.AppendLine($"{weakReferenceItem.TypeName} -> has a suspected memory leak. Create Date={weakReferenceItem.CreateDate} Done Date={weakReferenceItem.DoneDate}");
                    findAtLeastOne = true;
                }
            }

            return findAtLeastOne ? logs.ToString() : "Not found a suspected memory leak";
        }
    }
}
