/**
 * @license Copyright (c) 2003-2020, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-oss-license
 */

// The editor creator to use.
import ClassicEditorBase from '../../node_modules/@ckeditor/ckeditor5-editor-classic/src/classiceditor';

import Essentials from '../../node_modules/@ckeditor/ckeditor5-essentials/src/essentials';
import Autoformat from '../../node_modules/@ckeditor/ckeditor5-autoformat/src/autoformat';
import Bold from '../../node_modules/@ckeditor/ckeditor5-basic-styles/src/bold';
import Italic from '../../node_modules/@ckeditor/ckeditor5-basic-styles/src/italic';
import BlockQuote from '../../node_modules/@ckeditor/ckeditor5-block-quote/src/blockquote';
import CKFinder from '../../node_modules/@ckeditor/ckeditor5-ckfinder/src/ckfinder';
import Heading from '../../node_modules/@ckeditor/ckeditor5-heading/src/heading';
import Indent from '../../node_modules/@ckeditor/ckeditor5-indent/src/indent';
import Link from '../../node_modules/@ckeditor/ckeditor5-link/src/link';
import List from '../../node_modules/@ckeditor/ckeditor5-list/src/list';
import Paragraph from '../../node_modules/@ckeditor/ckeditor5-paragraph/src/paragraph';
import PasteFromOffice from '../../node_modules/@ckeditor/ckeditor5-paste-from-office/src/pastefromoffice';
import Table from '../../node_modules/@ckeditor/ckeditor5-table/src/table';
import TableToolbar from '../../node_modules/@ckeditor/ckeditor5-table/src/tabletoolbar';
import TextTransformation from '../../node_modules/@ckeditor/ckeditor5-typing/src/texttransformation';
// import InsertAsset from '../../media-plugin/orchardcore-media';

import InsertAsset from '../../ckeditor5-orchardcore-media/src/orchardcore-media';

// import InsertAsset from './orchardcore-media'

export default class ClassicEditor extends ClassicEditorBase {}

// Plugins to include in the build.
ClassicEditor.builtinPlugins = [
	Essentials,
	Autoformat,
	Bold,
	Italic,
	BlockQuote,
	CKFinder,
	Heading,
	Indent,
	Link,
	List,
	Paragraph,
	PasteFromOffice,
	Table,
	TableToolbar,
	TextTransformation,
	InsertAsset
];

// Editor configuration.
ClassicEditor.defaultConfig = {
	toolbar: {
		items: [
			'heading',
			'|',
			'bold',
			'italic',
			'link',
			'bulletedList',
			'numberedList',
			'|',
			'indent',
			'outdent',
			'|',
			'insertImage',
			'blockQuote',
			'insertTable',
			'undo',
			'redo'
		]
	},
	table: {
		contentToolbar: [
			'tableColumn',
			'tableRow',
			'mergeTableCells'
		]
	},
	// This value must be kept in sync with the language defined in webpack.config.js.
	language: 'en'
};