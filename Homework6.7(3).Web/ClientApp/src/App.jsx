import React, { useState, useEffect } from 'react';
import axios from 'axios'
import 'bootstrap/dist/css/bootstrap.min.css';

const App = () => {

    const [items, setItems] = useState([]);
    useEffect(() => {
        const loadData = async () => {
            const { data } = await axios.get('api/dandeal/getitems')
            setItems(data)
        }
        loadData();
        console.log(items.image)
    }, [])

    return <>
    
        <div className='container mt-5'>
            <div className='row'>
                <table className='table table-hover'>
                    <thead>
                        <tr>
                            {/* <th>Image</th> */}
                            <th>Title</th>
                            <th>Details</th>
                        </tr>
                    </thead>
                    <tbody>
                    {items.map(item => {
                            return <tr key={item.url}>
                                {/* <td><img src={item.image} style={{width:400}} /></td> */}
                                <td>
                                    <a target="_blank" href={item.url}>{item.title}</a>
                                </td>
                                <td>
                                    {item.details}
                                </td>                                
                            </tr>
                        })}
                    </tbody>
                </table>
            </div>
        </div>
    </>
}

export default App;