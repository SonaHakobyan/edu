import React, { useState } from "react";

const ErrorModal = props => {
    const [show, setShow] = useState(props.show);
    const handleClose = () => setShow(false);

    return (
        <div class="popup" onclick={handleClose}> aaaa
            <span class="popuptext" id="myPopup">Popup text...</span>
        </div>
    );
}

export default ErrorModal;