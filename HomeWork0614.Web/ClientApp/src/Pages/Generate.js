import React, {useState, useEffect} from "react";

const Generate = () => {

    const [amount, setAmount] = useState([])

    const GenerateRandomList = ()=>{
        window.location.href=`/api/People/createCsvFile?amount=${amount}`
    }

    return (
        <div class="d-flex w-100 justify-content-center align-self-center">
            <div class="row">
                <input type="text" class="form-control-lg" onChange={e => setAmount(e.target.value)} placeholder="Amount"/>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <button class="btn btn-primary btn-lg" onClick={GenerateRandomList}>Generate</button>
                </div>
            </div>
        </div>
    )
}

export default Generate;