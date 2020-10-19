import Plugin from '@ckeditor/ckeditor5-core/src/plugin';
import shortcodeIcon from './shortcode.svg';
import ButtonView from '@ckeditor/ckeditor5-ui/src/button/buttonview';


export default class InsertOrchardCoreShortcode extends Plugin {
    init() {
        const editor = this.editor;

        editor.ui.componentFactory.add( 'insertShortcode', locale => {
            const view = new ButtonView( locale );

            view.set( {
                label: 'Insert shortcode',
                icon: shortcodeIcon,
                tooltip: true
            } );

            // Callback executed once the image is clicked.
            view.on( 'execute', () => {
                shortcodesApp.init(function (defaultValue) {
                    editor.model.change( writer => {
                        editor.model.insertContent(writer.createText( defaultValue ), editor.model.document.selection);
                    } );   
                });
            } );

            return view;
        } );        
    }
}