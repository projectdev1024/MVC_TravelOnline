
        $('.rdtrongnuoc').click(function (e) {
            e.preventDefault();
            var ckbox = $(this);
            var $select = $('#diemden');
            var id = ckbox.data('id');
            $select.empty();
            $.ajax({
                url: '/DiemDen/GetDiemDen',
                data: { id: id },
                dataType: "json",
                type:'POST',
                success: function (result) {
                   
                    $.each(result, function (i, result) {
                        $('<option>', {
                            value: result.madd
                        }).html(result.diemden).appendTo($select);
                    });
                    ckbox.prop("checked", true);
                }
            });
            
        });

        $('.rdnuocngoai').click(function (e) {
            e.preventDefault();
            var ckbox = $(this);
            var $select = $('#diemden');
            var id = ckbox.data('id');
            $select.empty();
            $.ajax({
                url: '/DiemDen/GetDiemDen',
                data: { id: id },
                dataType: "json",
                type: 'POST',
                success: function (result) {

                    $.each(result, function (i, result) {
                        $('<option>', {
                            value: result.madd
                        }).html(result.diemden).appendTo($select);
                    });
                    ckbox.prop("checked", true);
                }
            });

        });
