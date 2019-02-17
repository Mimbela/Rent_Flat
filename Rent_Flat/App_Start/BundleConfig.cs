using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Rent_Flat.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //------------------------------------------------------------------------------------------SCRIPTS FRONT
            bundles.Add(new ScriptBundle("~/commonscripts").
                Include("~/Content/Front/js/jquery-3.2.1.min.js",
                "~/Content/Front/styles/bootstrap4/popper.js",
                "~/Content/Front/styles/bootstrap4/bootstrap.min.js",
                "~/Content/Front/plugins/easing/easing.js",
                "~/Content/Front/plugins/parallax-js-master/parallax.min.js"
                , "~/Content/Front/plugins/OwlCarousel2-2.2.1/owl.carousel.js"));

            bundles.Add(new ScriptBundle("~/homescripts").
                Include("~/Content/Front/js/jquery-3.2.1.min.js",
                "~/Content/Front/js/custom.js"));

            bundles.Add(new ScriptBundle("~/acercadescripts").
                Include("~/Content/Front/js/jquery-3.2.1.min.js",
                "~/Content/Frontplugins/greensock/TweenMax.min.js",
                "~/Content/Front/plugins/greensock/TimelineMax.min.js",
                "~/Content/Front/plugins/scrollmagic/ScrollMagic.min.js",
                "~/Content/Front/plugins/greensock/animation.gsap.min.js",
                "~/Content/Front/plugins/greensock/ScrollToPlugin.min.js",
                "~/Content/Front/plugins/OwlCarousel2-2.2.1/owl.carousel.js",
                "~/Content/Front/js/about.js"));

            bundles.Add(new ScriptBundle("~/propiedadescripts").
                Include("~/Content/Front/js/jquery-3.2.1.min.js",
                "~/Content/Front/plugins/greensock/TweenMax.min.js",
                "~/Content/Front/plugins/greensock/TimelineMax.min.js",
                "~/Content/Front/plugins/scrollmagic/ScrollMagic.min.js",
                "~/Content/Front/plugins/greensock/animation.gsap.min.js",
                "~/Content/Front/plugins/greensock/ScrollToPlugin.min.js",
                "~/Content/Front/plugins/OwlCarousel2-2.2.1/owl.carousel.js",
                "~/Content/Front/js/properties.js"));

            bundles.Add(new ScriptBundle("~/contactscripts").
                Include("~/Content/Front/js/jquery-3.2.1.min.js",
                "~/Content/Front/plugins/rangeslider.js-2.3.0/rangeslider.min.js",
                "~/Content/Front/https://maps.googleapis.com/maps/api/js?v=3.exp&key=AIzaSyCIwF204lFZg1y4kPSIhKaHEXMLYxxuMhA",
                "~/Content/Front/js/contact.js"));

            //------------------------------------------------------------------------------------------STYLES BACK PREGUNTAR A PACO¡¡
            //bundles.Add(new StyleBundle("~/backcommonstyles").
            //    Include("~/Content/Back/css/font-face.css",
            //    "~/Content/Back/vendor/font-awesome-4.7/css/font-awesome.min.css",
            //    "~/Content/Back/vendor/font-awesome-5/css/fontawesome-all.min.css",
            //    "~/Content/Back/vendor/mdi-font/css/material-design-iconic-font.min.css",
            //    "~/Content/Back/vendor/bootstrap-4.1/bootstrap.min.css",
            //    "~/Content/Back/vendor/animsition/animsition.min.css",
            //    "~/Content/Back/vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css",
            //    "~/Content/Back/vendor/wow/animate.css",
            //    "~/Content/Back/vendor/css-hamburgers/hamburgers.min.css",
            //    "~/Content/Back/vendor/slick/slick.css",
            //    "~/Content/Back/vendor/select2/select2.min.css",
            //    "~/Content/Back/vendor/perfect-scrollbar/perfect-scrollbar.css"));




            //-------------------------------------------------------------------------------------------ESTILOS FRONT
            bundles.Add(new StyleBundle("~/commonstyles").
                Include("~/Content/Front/styles/bootstrap4/bootstrap.min.css",
                "~/Content/Front/plugins/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Content/Front/plugins/OwlCarousel2-2.2.1/owl.carousel.css",
                "~/Content/Front/plugins/OwlCarousel2-2.2.1/owl.theme.default.css",
                "~/Content/Front/plugins/OwlCarousel2-2.2.1/animate.css"));

            bundles.Add(new StyleBundle("~/homestyles").
                Include("~/Content/Front/styles/main_styles.css",
                "~/Content/Front/styles/responsive.css"));

            bundles.Add(new StyleBundle("~/acercadestyles").
                Include("~/Content/Front/styles/about.css",
                "~/Content/Front/styles/about_responsive.css"));

            bundles.Add(new StyleBundle("~/propiedadesstyles").
                Include("~/Content/Front/styles/properties.css",
                "~/Content/Front/styles/properties_responsive.css"));

            bundles.Add(new StyleBundle("~/contactstyle").
                Include("~/Content/Front/plugins/rangeslider.js-2.3.0/rangeslider.css",
                "~/Content/Front/styles/contact.css",
                "~/Content/Front/styles/contact_responsive.css"));
            //------------------------------------------------------------------------------------------SCRIPTS BACK
            bundles.Add(new ScriptBundle("~/backcommonscripts").
                Include("~/Content/Back/vendor/jquery-3.2.1.min.js",
                "~/Content/Back/vendor/bootstrap-4.1/popper.min.js",
                "~/Content/Back/vendor/bootstrap-4.1/bootstrap.min.js",
                "~/Content/Back/vendor/slick/slick.min.js",
                "~/Content/Back/vendor/wow/wow.min.js",
                "~/Content/Back/vendor/animsition/animsition.min.js",
                "~/Content/Back/vendor/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/Content/Back/vendor/counter-up/jquery.waypoints.min.js",
                "~/Content/Back/vendor/counter-up/jquery.counterup.min.js",
                "~/Content/Back/vendor/circle-progress/circle-progress.min.js",
                "~/Content/Back/vendor/perfect-scrollbar/perfect-scrollbar.js",
                "~/Content/Back/vendor/chartjs/Chart.bundle.min.js",
                "~/Content/Back/vendor/select2/select2.min.js",
                "~/Content/Back/js/main.js"));









           
        }
    }
}