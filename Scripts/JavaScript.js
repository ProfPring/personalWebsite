(function ($) {

    var jump = function (e) {
        if (e) {
            e.preventDefault();
            var target = $(this).attr("href");
        } else {
            var target = location.hash
        }

        $('html, body').animate(
            {
                scrollTop: $(target).offset().top

            }, 2000, function () {
                location.hash = target;
            });
    }

    $(document).ready(function () {
        console.log("working");
        $('a[href^=#]').bind("click", jump);

        if (location.hash) {
            setTimeout(function () {
                $('html, body').scrollTop(5).show;
                jump();
            }, 0);
        } else {
            $('html, body').show();
        }

        $("#githubBttn").click(function () {
            url = "https://github.com/ProfPring";
            //window.location = url;
            window.open(url)
        });

        $('#ArtContainer2').click(function () {
            console.log("clicked")

        })

        $('#ArtContainer3').click(function () {
            console.log("clicked")

        })

        $('#ArtContainer4').click(function () {
            console.log("clicked")

        })





        var ClickToClose = $('#closeB').click(function () {
            console.log("clicked to close");

            $('#closeB').toggleClass('closebtn-closed');
            $('#closeB').toggleClass('closebtn');


            $("#openclose").toggleClass('Closed');
            $("#openclose").toggleClass('open');


            $('#navbar').toggleClass('sidebar');
            $('#navbar').toggleClass('sidebar-Open');


            $('#navbar-btn').toggleClass('navbar-btn-hide');
            $('#navbar-btn').toggleClass('navbar-btn');

            $('.right').toggleClass('active');
        });

        var ClickToOpen = $('#navbar-btn').click(function ClickToOpen() {
            console.log("clicked navbar btn");

            $('#closeB').toggleClass('closebtn-closed');
            $('#closeB').toggleClass('closebtn');



            $("#openclose").toggleClass('open');
            $("#openclose").toggleClass('Closed');


            $('#navbar').toggleClass('sidebar');
            $('#navbar').toggleClass('sidebar-Open');

            $('#navbar-btn').toggleClass('navbar-btn');
            $('#navbar-btn').toggleClass('navbar-btn-hide');

            $('.right').toggleClass('active');
        });


        var a = $(".Closed").find("a");
        $(a).on("click", function () {
            console.log("clicked");


            $('#closeB').toggleClass('closebtn-closed');
            $('#closeB').toggleClass('closebtn');


            $("#openclose").toggleClass('Closed');
            $("#openclose").toggleClass('open');


            $('#navbar').toggleClass('sidebar');
            $('#navbar').toggleClass('sidebar-Open');


            $('#navbar-btn').toggleClass('navbar-btn-hide');
            $('#navbar-btn').toggleClass('navbar-btn');

            $('.right').toggleClass('active');

        });
        function download(filename, text) {
            var element = document.createElement('a');
            element.style.display = 'none';
            //define data of file when using EncodeURIComponent
            element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));

            //add Attribute of hidden link
            element.setAttribute('download', filename);
            document.body.appendChild(element);

            //simulate click of link cretated
            element.click();


            document.body.removeChild(element)
        }

        //when user clicks button start downlaod
        //start file download
        $('#download-btn').on("click", function () {

            var text = $('#text-val').val;
            var filename = $('#filename').val;

            download(filename, text);

        }, false);



    });
})(jQuery)