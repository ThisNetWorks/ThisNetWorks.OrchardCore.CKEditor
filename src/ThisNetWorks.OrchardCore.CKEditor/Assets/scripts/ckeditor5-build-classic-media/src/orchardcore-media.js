import Plugin from '@ckeditor/ckeditor5-core/src/plugin';
import imageIcon from '@ckeditor/ckeditor5-core/theme/icons/image.svg';
import ButtonView from '@ckeditor/ckeditor5-ui/src/button/buttonview';


export default class InsertAsset extends Plugin {
    init() {
        const editor = this.editor;

        editor.ui.componentFactory.add( 'insertImage', locale => {
            const view = new ButtonView( locale );

            view.set( {
                label: 'Insert image',
                icon: imageIcon,
                tooltip: true
            } );

            // Callback executed once the image is clicked.
            view.on( 'execute', () => {

                $("#mediaApp").detach().appendTo('#mediaModalBody .modal-body');
                $("#mediaApp").show();
                mediaApp.selectedMedias = [];
                var modal = $('#mediaModalBody').modal();
                //disable an reset on click event over the button to avoid issue if press button multiple times or have multiple editor
                $('#mediaHtmlFieldSelectButton').off('click');
                $('#mediaBodySelectButton').on('click', function (v) {

                    var content = '';
                    
                    for (i = 0; i < mediaApp.selectedMedias.length; i++) {
                        var mediaBodyContent = ' [image]' + mediaApp.selectedMedias[i].mediaPath + '[/image]';
                        content = content  + mediaBodyContent;
                    }

                    editor.model.change( writer => {
                        editor.model.insertContent(writer.createText( content ), editor.model.document.selection);
                    } );
                    
                    $('#mediaModalBody').modal('hide');
                    return true;
                });

            } );

            return view;
        } );        
    }
}