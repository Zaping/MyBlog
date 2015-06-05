/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    config.entities = true;
    config.basicEntities = true;

    config.entities_greek = false;
    config.entities_latin = false;

    config.entities_additional = '';

    config.htmlEncodeOutput = true;
}