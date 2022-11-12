using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public enum BookType
    {
        Unknown,
        ActionAndAdventure,
        Classics,
        ComicBookOrGraphicNovel,
        DetectiveAndMystery,
        Fantasy,
        HistoricalFiction,
        Horror,
        LiteraryFiction,
    }

    public enum City
    {
        Unknown,
        CanTho,
        BacLieu,
        Other,
    }

    public enum State
    {
        Unknown,
        Asia,
        Europe,
        Other,
    }

    public enum Country
    {
        Unknown,
        VietNam,
        China,
        Other
    }
}
