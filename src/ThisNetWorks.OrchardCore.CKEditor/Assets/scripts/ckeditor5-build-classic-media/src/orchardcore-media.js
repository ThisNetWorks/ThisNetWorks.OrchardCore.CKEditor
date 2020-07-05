import Plugin from '@ckeditor/ckeditor5-core/src/plugin';
import imageIcon from '@ckeditor/ckeditor5-core/theme/icons/image.svg';
import ButtonView from '@ckeditor/ckeditor5-ui/src/button/buttonview';


export default class InsertAsset extends Plugin {
    init() {
        console.log( 'InsertAsset was initialized' );
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
                // const imageURL = prompt( 'Image URL' );

                $("#mediaApp").detach().appendTo('#mediaModalBody .modal-body');
                $("#mediaApp").show();
                mediaApp.selectedMedias = [];
                var modal = $('#mediaModalBody').modal();
                //disable an reset on click event over the button to avoid issue if press button multiple times or have multiple editor
                $('#mediaHtmlFieldSelectButton').off('click');
                $('#mediaBodySelectButton').on('click', function (v) {
                    // trumbowyg.restoreRange();
                    // trumbowyg.range.deleteContents();
                    
                    for (i = 0; i < mediaApp.selectedMedias.length; i++) {
                        var mediaBodyContent = ' [image]' + mediaApp.selectedMedias[i].mediaPath + '[/image]';
                        console.log(mediaBodyContent);
                        // var node = document.createTextNode(mediaBodyContent);
                        // trumbowyg.range.insertNode(node);
                    }
                    
                    // trumbowyg.syncCode();
                    // trumbowyg.$c.trigger('tbwchange');
                    // //avoid tag to be selected after add it
                    // trumbowyg.$c.focus();

                    $('#mediaModalBody').modal('hide');
                    return true;
                });




            } );

            return view;
        } );        
    }
}