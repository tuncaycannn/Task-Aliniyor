using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.Abstract
{
    //İnterface aracılığı ile filtrelenme işlemi yeni bir veri kümesi eklendiğinde veya düzenlenmesi gerektiğinde kullanılır.
   public interface ICityRepository
    {
        string GetAdress(string from, string filterby, string value, string shorting);
    }
}
