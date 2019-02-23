import firebase from 'firebase'
import config from './configs/firebase'


const app = firebase.initializeApp(config);
const provider = new firebase.auth.GoogleAuthProvider();


export default {
    app,
    provider
}