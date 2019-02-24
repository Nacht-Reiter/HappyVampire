import firebase from 'firebase'
import config from './configs/firebase'


firebase.initializeApp(config);
const provider = new firebase.auth.GoogleAuthProvider();


export default {
    firebase,
    provider
}