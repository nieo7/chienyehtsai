$.fn.zipCode = function (settings) {
    var obj = jQuery.parseJSON(ZipCodeData);
    var _callback = function () {
        var area = $('#' + _settings.CityArea);
        var city = $(this);
        area.empty().append('<option value="">請選擇</option>');
        if (city != '') {
            $('#' + _settings.CityHidd).val(city.val());
            _getcityArea(obj[city.val()], area);
        }
    };

    var _getcityArea = function (root, tag) {
        $.each(root, function (key, data) {
            tag.append(
						$('<option></option>').val(data.ZipCode).html(data.CityArea)
					);
        });
        tag.find('option').each(function () {
            this.selected = (this.text == _settings.CityAreaDefault);
        });
        $('#' + _settings.ZipCode).val(tag.val());
    };

    var _defaultSettings = {
        bind: 'change',
        CityDefaul: '',
        CityHidd: 'CityHidd',
        AreaHidd: 'AreaHidd',
        CityAreaDefault: '',
        CityArea: 'CityArea',
        ZipCode: 'ZipCode',
        ZipCodeTextBox: 'ZipCodeTextBox',
        callback: _callback
    };

    var _settings = $.extend(_defaultSettings, settings);

    var _handler = function () {
        var x = this
        $.each(obj, function (key, data) {
            $(x).append(
				$('<option></option>').val(key).html(key)
			);
        });

        if (_settings.CityDefaul != '') {
            $(x).val(_settings.CityDefaul);
            _getcityArea(obj[_settings.CityDefaul], $('#' + _settings.CityArea));
        };

        $(x).bind(_settings.bind, _settings.callback);

        $('#' + _settings.CityArea).bind('change', function () {
            var z = $('#' + _settings.ZipCode);
            z.val($(this).val());
            var zb = $('#' + _settings.ZipCodeTextBox);
            zb.val($(this).val());
            $('#' + _settings.AreaHidd).val($('#' + _settings.CityArea + ' option:selected').text());
        });
    };

    return this.each(_handler);
};