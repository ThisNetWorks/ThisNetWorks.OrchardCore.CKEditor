import Plugin from '@ckeditor/ckeditor5-core/src/plugin';
import imageIcon from '@ckeditor/ckeditor5-core/theme/icons/image.svg';
import ButtonView from '@ckeditor/ckeditor5-ui/src/button/buttonview';


export default class InsertOrchardCoreMedia extends Plugin {
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
                // It doesn't matter which modal is bound to, so long as its only one, and is unbound later.
                var modalSelector = '#mediaModalBody';
                var selectButtonSelector = '#mediaBodySelectButton';
                var modal = $('#mediaModalBody');
                if (modal.length === 0)
                {
                    modalSelector = '#mediaModalHtmlField';
                    selectButtonSelector = '#mediaHtmlFieldSelectButton';
                }

                function appendMedia (){
                    var content = '';
                    
                    for (i = 0; i < mediaApp.selectedMedias.length; i++) {
                        var mediaBodyContent = ' [image]' + mediaApp.selectedMedias[i].mediaPath + '[/image]';
                        content = content  + mediaBodyContent;
                    }

                    editor.model.change( writer => {
                        editor.model.insertContent(writer.createText( content ), editor.model.document.selection);
                    } );
                    
                    $(modalSelector).modal('hide');
                    // Unbind select button event.
                    $(selectButtonSelector).off('click', appendMedia);

                    return true;
                }
                $("#mediaApp").detach().appendTo(modalSelector + ' .modal-body');
                $("#mediaApp").show();
                mediaApp.selectedMedias = [];
                $(modalSelector).modal();
                $(selectButtonSelector).on('click', appendMedia);
            } );

            return view;
        } );        
    }
}