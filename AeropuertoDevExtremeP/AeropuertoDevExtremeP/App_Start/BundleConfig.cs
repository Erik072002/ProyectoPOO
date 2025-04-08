using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace AeropuertoDevExtremeP {

    public class BundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {

            var scriptBundle = new Bundle("~/Scripts/bundle");
            var styleBundle = new Bundle("~/Content/bundle");

            // jQuery
            scriptBundle
                .Include("~/Scripts/jquery-3.6.3.js");

            // Bootstrap
            scriptBundle
                .Include("~/Scripts/bootstrap.js");

            // Bootstrap
            styleBundle
                .Include("~/Content/bootstrap.css");

            // Custom site styles
            styleBundle
                .Include("~/Content/dx.material.custom-schem.css");

            bundles.Add(new StyleBundle("~/Content/material").Include(
                                "~/Content/material.custom-scheme2.css"
                                                                    ));


            bundles.Add(scriptBundle);
            bundles.Add(styleBundle);

            //BundleTable.EnableOptimizations = true;
        }
    }
}