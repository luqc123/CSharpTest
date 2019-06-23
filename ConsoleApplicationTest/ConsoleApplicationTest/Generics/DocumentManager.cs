using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest.Generics
{
    public class DocumentManager<TDocument>
        where TDocument : IDocument
    {
        private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();

        public void AddDocument(TDocument doc)
        {
            lock(this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public bool IsDocumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }

        public TDocument GetDocument()
        {
            //default 引用类型赋值为null 值类型赋值为0
            TDocument doc = default(TDocument);
            lock(this)
            {
                doc = documentQueue.Dequeue();
            }
            return doc;
        }

        public void DisplayAllDocument()
        {
            foreach(var doc in documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }
    }
}
