using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models {
    public class AboutModel {
        public int Id { get; set; }
        public string? Info { get; set; }
    }

    public class ViewModel {
        public IEnumerable<AboutModel>? AboutList { get; set;}
    }
}