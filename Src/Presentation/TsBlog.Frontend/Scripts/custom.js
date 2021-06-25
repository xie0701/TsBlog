jQuery(document).ready(function () {
    (function (a) {
        a.fn.menumaker = function (g) {
            var f = a(this), h = a.extend({ format: "dropdown", sticky: false }, g);
            return this.each(function () {
                a(this).find(".button").on("click", function () {
                    a(this).toggleClass("menu-opened");
                    var e = a(this).next("ul");
                    if (e.hasClass("open")) {
                        e.slideToggle().removeClass("open")
                    }
                    else {
                        e.slideToggle().addClass("open");
                        if (h.format === "dropdown") {
                            e.find("ul").show()
                        }
                    }
                });
                f.find("li ul").parent().addClass("has-sub");
                var c;
                c = function () {
                    f.find(".has-sub").prepend('<span class="submenu-button"></span>');
                    f.find(".submenu-button").on("click", function () {
                        a(this).toggleClass("submenu-opened");
                        if (a(this).siblings("ul").hasClass("open")) {
                            a(this).siblings("ul").removeClass("open").slideToggle()
                        }
                        else {
                            a(this).siblings("ul").addClass("open").slideToggle()
                        }
                    })
                };
                if (h.format === "multitoggle") {
                    c()
                }
                else {
                    f.addClass("dropdown")
                }
                if (h.sticky === true) {
                    f.css("position", "fixed")
                }
                var d;
                d = function () {
                    var e = 1000; if (a(window).width() > e) {
                        f.find("ul").show()
                    }
                    if (a(window).width() <= e) {
                        f.find("ul").hide().removeClass("open")
                    }
                };
                d();
                return a(window).on("resize", d)
            })
        }
    })(jQuery);
    $("#easy-menu").menumaker({ format: "multitoggle" });
    (function (a) {
        function h(d) {
            var c = "webkitAnimationEnd animationend";
            d.each(function () {
                var j = a(this), e = j.data("animation");
                j.addClass(e).one(c, function () { j.removeClass(e) })
            })
        }
        var g = a("#carousel-example-generic"), f = g.find(".item:first").find("[data-animation ^= 'animated']");
        g.carousel(); h(f);
        g.carousel("pause");
        g.on("slide.bs.carousel", function (d) {
            var c = a(d.relatedTarget).find("[data-animation ^= 'animated']");
            h(c)
        })
    })(jQuery);
    $(".search-box .search-icon").on("click", function (a) {
        a.preventDefault(); $(".top-search-input-wrap").addClass("show")
    });
    $(".top-search-input-wrap .top-search-overlay, .top-search-input-wrap .close-icon").on("click", function () {
        $(".top-search-input-wrap").removeClass("show")
    });
    $("#humbarger").on("click", function () {
        $(".hidden-sidebar").animate().toggleClass("sidebar-show")
    });
    $("#hidden-sidebar-close span").on("click", function () {
        $(".hidden-sidebar").animate().removeClass("sidebar-show")
    });
    var b = $(window).height();
    $(".hidden-sidebar").css({ height: b });
    $(window).on("resize", function () {
        var a = $(window).height();
        $(".hidden-sidebar").css({ height: a })
    });
    if ($(".hidden-sidebar").length) {
        $(".hidden-sidebar").niceScroll({
            cursorcolor: "#94c501",
            cursoropacitymin: 0,
            cursoropacitymax: 1,
            cursorwidth: "0",
            cursorborder: "0px solid #fff",
            cursorborderradius: "0px",
        })
    }
    if ($(".blog-gallery-post").length) {
        $(".blog-gallery-post").owlCarousel({
            items: 1,
            loop: true,
            nav: true,
            dots: false,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        })
    }
    if ($(".row-eq-height").length) {
        $(".row-eq-height >div").matchHeight()
    }
});