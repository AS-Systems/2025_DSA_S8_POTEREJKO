using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model.Enums
{
    public enum Genre
    {
        [Description("Fiction")] Fiction,
        [Description("Non-Fiction")] NonFiction,
        [Description("Mystery")] Mystery,
        [Description("Thriller")] Thriller,
        [Description("Romance")] Romance,
        [Description("Science Fiction")] ScienceFiction,
        [Description("Fantasy")] Fantasy,
        [Description("Historical Fiction")] HistoricalFiction,
        [Description("Horror")] Horror,
        [Description("Biography")] Biography,
        [Description("Autobiography")] Autobiography,
        [Description("Memoir")] Memoir,
        [Description("Young Adult")] YoungAdult,
        [Description("Children")] Children,
        [Description("Graphic Novel")] GraphicNovel,
        [Description("Classic")] Classic,
        [Description("Adventure")] Adventure,
        [Description("Dystopian")] Dystopian,
        [Description("Contemporary")] Contemporary,
        [Description("Literary Fiction")] LiteraryFiction,
        [Description("Crime")] Crime,
        [Description("Paranormal")] Paranormal,
        [Description("Self Help")] SelfHelp,
        [Description("Science")] Science,
        [Description("Philosophy")] Philosophy,
        [Description("Poetry")] Poetry,
        [Description("Humor")] Humor,
        [Description("Spirituality")] Spirituality,
        [Description("Travel")] Travel,
        [Description("True Crime")] TrueCrime
    }
}
