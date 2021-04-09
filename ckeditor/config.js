/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = 'zh-tw';
    // config.uiColor = '#AADC6E';
    // config.uiColor = '#AADC6E';
    config.toolbar =
      [
         ['Source', '-', 'Preview', '-'],
         ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'],
         ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
         '/',
         ['Bold', 'Italic', 'Underline'],
         ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'],
         ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
         ['Link', 'Unlink', 'Anchor'],
         ['addpic', 'Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'], //此处的addpic为我们自定义的图标，非CKeditor提供。
         '/',
         ['Styles', 'Format', 'Font', 'FontSize'],
         ['TextColor', 'BGColor'],
     ];

    config.toolbar_Full =
    [
    ['Source', '-', 'Save', 'NewPage', 'Preview', '-', 'Templates'],
    ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
    ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
    ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
    '/',
    ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
    ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
    ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
    ['Link', 'Unlink', 'Anchor'],
    ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'],
    '/',
    ['Styles', 'Format', 'Font', 'FontSize'],
    ['TextColor', 'BGColor'],
    ['Maximize', 'ShowBlocks', '-', 'About']
    ];

    config.font_defaultLabel = '新細明體';
    config.font_names = 'Arial;Times New Roman;Verdana;細明體;新細明體;微軟正黑體;標楷體';
    config.fontSize_defaultLabel = '12px';
    //字體編輯時可選的字體大小 plugins/font/plugin.js
    config.fontSize_sizes = '8/8px;9/9px;10/10px;11/11px;12/12px;14/14px;16/16px;18/18px;20/20px;22/22px;24/24px;26/26px;28/28px;36/36px;48/48px;72/72px';

};
