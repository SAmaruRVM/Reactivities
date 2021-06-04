import React, { useEffect, useState } from 'react';
import MainImage from './drinks.jpg'
import './App.css';
import { Header, List, ListItem } from 'semantic-ui-react'

function App() {

  const [activities, setActivities] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5000/api/Activities')
      .then(response => response.json())
      .then(data => setActivities(data))
  }, []);


  return (
    <div className="App">
      <Header as="h2" icon="users" content="Reactivities" />
      <header className="App-header">
        <List>
          {activities.map((activity: any) => (
            <ListItem key={activity.id} style={{ color: '#000', listStyleType: 'none' }}>
              <h4>{activity.title}</h4>
              <p>{activity.description}</p>
              <p>@{activity.city} in {activity.venue}</p>
              <hr />
            </ListItem>
          ))}
        </List>
      </header>
    </div>
  );
}

export default App;