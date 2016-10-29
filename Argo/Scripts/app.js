$(document).ready(function () {
    function initHeaderStick() {
        var $window = $(window),
            $header = $('.header-bar');

        function update() {
            var scrollTop = $window.scrollTop();

            $header.toggleClass('is-fixed', scrollTop > 0);
        }

        $(window).on('scroll', update);
        update();
    }

    function initDropdown() {
        $('#lang-dropdown').on('click', function (e) {
            if (!$(e.target).is('a')) {
                e.preventDefault();
                e.stopPropagation();
            }

            var $dropdown = $(e.currentTarget);

            $dropdown.toggleClass('is-opened');

            var event = $dropdown.hasClass('is-opened') ? 'dropdown-opened' : 'dropdown-closed';
            $(window).trigger(event);
        });

        $(window).on('dropdown-opened', function () {
            $(document).on('click.dropdown', function (e) {
                var $target = $(e.target);

                if ($target.closest('.dropdown').length === 0) {
                    $('#lang-dropdown').trigger('click');
                }
            });
        });

        $(window).on('dropdown-closed', function () {
            $(document).off('click.dropdown');
        });
    }

    function initSmoothScrolling() {
        var $links = $('.top-menu a[href^=#]'),
            scrollShift = 85;

        $links.on('click', function (e) {
            e.preventDefault();

            var target = $(this).attr('href'),
                $target = $(target);

            $('html, body').animate({
                scrollTop: $target.offset().top - scrollShift
            }, 500);
        });
    }

    function initMenu() {
        var $menu = $('#top-menu'),
            $button = $('.top-menu-toggle');

        $button.on('click', function (e) {
            e.preventDefault();

            $button.toggleClass('is-opened');
            $menu.toggleClass('is-opened', $button.hasClass('is-opened'));
        });
    }

    initHeaderStick();
    initDropdown();
    initSmoothScrolling();
    initMenu();
});
