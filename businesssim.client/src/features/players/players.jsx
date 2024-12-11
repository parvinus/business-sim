import React, { useState } from 'react';

const AddPlayer = () => {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        const player = { name, email };

        try {
            const response = await fetch('https://api.example.com/players', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(player),
            });

            if (response.ok) {
                alert('Player added successfully');
                setName('');
                setEmail('');
            } else {
                alert('Failed to add player');
            }
        } catch (error) {
            console.error('Error:', error);
            alert('Error adding player');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Name:</label>
                <input
                    type="text"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>Email:</label>
                <input
                    type="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />
            </div>
            <button type="submit">Add Player</button>
        </form>
    );
};

export default AddPlayer;