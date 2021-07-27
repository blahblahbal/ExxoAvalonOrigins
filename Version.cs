using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExxoAvalonOrigins
{
    class Version
    {
        public int rewrite;
        public int major;
        public int minor;
        public int fix;

        public Version(int rewrite, int major, int minor, int fix)
        {
            this.rewrite = rewrite;
            this.major = major;
            this.minor = minor;
            this.fix = fix;
        }

        public Version(String version)
        {
            var vStrs = version.Split('.');
            rewrite = int.Parse(vStrs[0]);
            major = int.Parse(vStrs[1]);
            minor = int.Parse(vStrs[2]);
            fix = int.Parse(vStrs[3]);
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}.{3}", rewrite, major, minor, fix);
        }

        public static bool operator< (Version v1, Version v2)
        {
            if (v2 == null) return false;
            if (v1 == null) return true;
            if (v1.rewrite != v2.rewrite) return v1.rewrite < v2.rewrite;
            if (v1.major != v2.major) return v1.major < v2.major;
            if (v1.minor != v2.minor) return v1.minor < v2.minor;
            return v1.fix < v2.fix;
        }

        public static bool operator >(Version v2, Version v1)
        {
            if (v1.rewrite != v2.rewrite) return v1.rewrite < v2.rewrite;
            if (v1.major != v2.major) return v1.major < v2.major;
            if (v1.minor != v2.minor) return v1.minor < v2.minor;
            return v1.fix < v2.fix;
        }
    }
}
