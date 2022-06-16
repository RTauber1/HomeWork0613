import React, {useState, useEffect} from "react";
import axios from 'axios';
import PersonRow from "../Components/PersonRow";

const Home = () => {
    const [people, setPeople] = useState([])

    const getPeople = async () => {
        const {data} = await axios.get('/api/People/getPeople')
        setPeople(data)
    }

    useEffect(() => {
        
        getPeople()
    }, [])

    const DeleteAll=async()=>{
        await axios.post('/api/People/deleteAll')
        getPeople()
    }


        
    return (
        <div className="container" >
            <div class="col-md-6 offset-md-3 mt-5">
                <button className="btn btn-danger btn-lg btn-block" onClick={DeleteAll}>Delete All</button>
            </div>
        <div className="row">
            <table className='table table-hover table-bordered table-striped'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Age</th>
                        <th>Adress</th>
                        <th>Email</th>
                        
                    </tr>
                </thead>
                {people.map((person, i) => <PersonRow  
                            person={person}/> )}
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
    )
}

export default Home;