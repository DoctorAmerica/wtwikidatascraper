using System.Text.RegularExpressions;

namespace utils {
    class CompReg {
        public static Regex rankPtrn = new Regex(
            "<div class=\"general_info_rank\"><a href=\"\\/Category:([a-zA-Z]*)_rank_ground_vehicles\" title=\"Category:\\1 rank ground vehicles\">([IVX]*) Rank<\\/a><\\/div>[\r\n]",
            RegexOptions.Compiled
        );
        public static Regex premiumPtrn = new Regex(
            "<a href=\"([^\"]*)\" title=\"([^\"]*)\">(PREMIUM)<\\/a>",
            RegexOptions.Compiled
        );
        public static Regex rolePtrn = new Regex(
            "<a href=\"\\/Category:([a-zA-Z_\\-]*)\" title=\"Category:([a-zA-Z \\-]*)\">(Light|Medium|Heavy|SPAA|Tank destroyer)( tanks?)?<\\/a>",
            RegexOptions.Compiled
        );
        public static Regex squadronPtrn = new Regex(
            "<a href=\"([^\"]*)\" title=\"([^\"]*)\">(SQUADRON)<\\/a>",
            RegexOptions.Compiled
        );
        public static Regex brPtrn = new Regex(
            "<td>([0-9.]{0,4})<\\/td>\n?"+ // AB
            "<td>([0-9.]{0,4})<\\/td>\n?"+ // RB
            "<td>([0-9.]{0,4})<\\/td>",    // SB
            RegexOptions.Compiled
        );
        public static Regex mobilityPtrn = new Regex(
            "<table class=\"wikitable\" style=\"text-align:center\" width=\"70%\">(.*?)<th> Arcade\n<\\/th>\n"+
                "<td> ([0-9.,]*)\n<\\/td>\n"+ // AB forward
                "<td> ([0-9.,]*)\n<\\/td>\n"+ // AB Reverse
                "<td rowspan=\"2\">([0-9.,]*)\n<\\/td>\n"+ // Weight
                "(<td rowspan=\"2\"> ([0-9.,]*)\n<\\/td>\n)?"+ // Add-on armor
                "<td> ([0-9._,]*)\n<\\/td>\n"+ // AB Stock Engine Power
                "<td> ([0-9.,]*)\n<\\/td>\n"+ // AB Upgraded Engine Power
                "<td> ([0-9._,]*)\n<\\/td>\n"+ // AB Stock Power-to-weight ratio
                "<td> ([0-9.,]*)\n<\\/td>"+   // AB Upgraded Power-to-weight ratio
                "<\\/tr>((.)*?)<\\/th>\n"+
                "<td> ([0-9.,]*)\n<\\/td>\n"+ // RB+SB forward
                "<td> ([0-9.,]*)\n<\\/td>\n"+ // RB+SB reverse
                "<td> ([0-9._,]*)\n<\\/td>\n"+ // RB+SB Stock Engine Power
                "<td> ([0-9.,]*)\n<\\/td>\n"+ // RB+SB Upgraded Engine Power
                "<td> ([0-9._,]*)\n<\\/td>\n"+ // RB+SB Stock Power-to-weight ratio
                "<td> ([0-9.,]*)\n<\\/td>"+   // RB+SB Upgraded Power-to-weight ratio
            "<\\/tr>((.)*?)<\\/table>",
            RegexOptions.Compiled | RegexOptions.Singleline
        );
        public static Regex repairPtrn = new Regex(
            "<div class=\"specs_char_line indent\"><span class=\"name\">(A|R|S)B<\\/span><span class=\"value\">([\\d\\s]*)(?:→([\\d\\s]+) )?<a href=\"\\/Silver_Lions\" title=\"Silver Lions\">((.)*?)<\\/span><\\/div>",
            RegexOptions.Compiled | RegexOptions.Singleline
        );
        public static Regex featuresPtrn = new Regex(
            "<div class=\"feature (.*?)\">.*\n",
            RegexOptions.Compiled
        );
        public static Regex mainArmamentPtrn = new Regex(
            """<h3><span class="mw-headline" id="Main_armament">Main armament<\/span><\/h3>\n<div class="specs_info weapon">\n<div class="specs_name_weapon">([0-9]*? x)?(?:&#32;)?(?:<a href="\/)?(.*?)(?:" class="mw-redirect)?(?:" title=".*?">.*?<\/a>)?<\/div>""",
            RegexOptions.Compiled
        );
        public static Regex diameterPtrn = new Regex(
            "([0-9]*) mm",
            RegexOptions.Compiled
        );
        public static Func<Match, string> diameterSub = (Match m) => m.Groups[1].Value + "mm";
        public static Regex multipleGunsPtrn = new Regex(
            "^([0-9]*) x "
        );
        public static Func<Match, string> multiGunSub = (Match m) => m.Groups[1].Value + "x ";
    }
    class RegFunc {
        public static string Replace(string input, Regex reg, Func<Match, string> replace) {
            return reg.Replace(input, delegate(Match m) {return replace(m);});
        }
    }
}