using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCvMiniProje.Models.entities;

namespace MvcCvMiniProje.repository
    //CRUD İŞLEMLERİNİ TEKRARSIZ YAPMAKTAN KURTARIR
{   //genericrepository clasıma bağlı T nesnemi oluşturdum
    //Bu T nesnem hem class olmalı hemde new() alabilmeli
    public class GenericRepository<T> where T:class,new()
    {
        dbcvmvcEntities ent = new dbcvmvcEntities();
        //LİSTELEME METODU
        public List<T> list()
        {
          return  ent.Set<T>().ToList();//T den gelecek olan değerleri list şeklinde döndür
        }
        //EKLEME METODU
        public void TAdd(T p)
        {
            ent.Set<T>().Add(p);
            ent.SaveChanges();
        }
        //silme işleminde veya güncelleme işleminde bir bulma yapabilmek için aşağıdaki methodu yazmam gerek
        public T find(Expression<Func<T,bool>>where)
        {  
            //where->şartımda belirtmiş olduğum değere göre 
            //tek bir değer döndür yani Ben Id'ye göre veya Ad'a göre 
            //değer döndürebilirim ona göre ilk değerini alacak
            return ent.Set<T>().FirstOrDefault(where);
        }

        //SİLME METODU
        public void TDelete(T p)
        {
            ent.Set<T>().Remove(p);
            ent.SaveChanges();
        }
        //GÜNCELLEME İÇİN VERİLERİ GETİRME İŞLEMİ
        //id ye göre verilerimizi getircez
        public T TGet(int id)
        {
            return ent.Set<T>().Find(id);
        }
        //GÜNCELLEME İŞLEMİ
        //atamayı yaptığımız için direk savechanges dedik galiba!!!
        public void TUpdate(T p) 
        {
            ent.SaveChanges();
        }
        //sonra bu sınıfımızdaki özellikleri kullanmamız için diğer repository sınıflarımızda bu sınıfı
        //miras alacaz







    }
}