using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Composite;

//component
public abstract class FileSystem {
    public string Name { get; set; }
    public abstract long GetSize();
    public FileSystem(string name) {
        Name = name;
    }
}

//leaf
public class File : FileSystem {
    private long _size;

    public File(string name, long size) : base(name) {
        _size = size;
    }

    public override long GetSize() {
        return _size;
    }
}

//composite
public class Directory : FileSystem {
    private long _size;
    private List<FileSystem> _items;
    public Directory(string name, int v) : base(name) {
        _items = new List<FileSystem>();
    }

    public override long GetSize() {
        var treeSize = _size;
        foreach (FileSystem fs in _items) {
            treeSize += fs.GetSize();
        }
        return treeSize;
    }
    public void Add(FileSystem fs) {
        _items.Add(fs);
    }
    public void Remove(FileSystem fs) {
        _items.Remove(fs);
    }

}