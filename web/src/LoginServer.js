let LoginServer = null;

export default{
    GetLoginServer : function(){
        if(LoginServer != null){
            return LoginServer;
        }
        var config = {
            authority: "https://localhost:6001",
            client_id: "blogjs",
            redirect_uri: "http://localhost:8080/callback.html",
            response_type: "id_token token",
            scope: "openid profile mangoblogApi mango.profile",
            post_logout_redirect_uri: "http://localhost:8080",
            userStore: new Oidc.WebStorageStateStore({ store: window.sessionStorage })
        };
        LoginServer = new Oidc.UserManager(config);
        return LoginServer;
    }
}