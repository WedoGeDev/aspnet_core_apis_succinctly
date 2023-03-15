using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepository.Core
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
}