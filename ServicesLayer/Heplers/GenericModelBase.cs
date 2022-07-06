using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Heplers
{
    public static class GenericModelBase<T> where T : BaseEntity
    {
        public static T SetAddDefualts(T entity, string userName)
        {

            entity.CreatedDate = DateTime.Now;
            entity.EntryUser = userName;
            entity.IsActive = true;
            return entity;
        }
         
    }
}
