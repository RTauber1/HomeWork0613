import React , {useRef} from "react";
import { useHistory } from "react-router-dom";
import axios from 'axios';

const Upload = () => {

    

        const toBase64 = file => new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = () => resolve(reader.result)
            reader.onerror = error => reject(error)
        });
    
        const theFile = useRef(null)
        const history = useHistory()
        const AddToPeople = async () => {
            const file = theFile.current.files[0]
            const base64File = await toBase64(file)
            const name = file.name;
            await axios.post('/api/people/uploadCsvFile', { base64File })
            history.push('/')
        }

    return (
        <div class="d-flex w-100 justify-content-center align-self-center">
            <div class="row">
                <div class="col-md-10">
                    <input type="file"  ref={theFile} class="form-control-lg"/>
                </div>
                <div class="col-md-2">
                        <button class="btn btn-primary btn-lg" onClick={AddToPeople}>Upload</button>
                </div>
            </div>
     </div>
    )
}

export default Upload;