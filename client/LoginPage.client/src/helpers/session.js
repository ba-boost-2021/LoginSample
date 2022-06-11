import { parseISO, differenceInMilliseconds, differenceInSeconds } from "date-fns";
export default {
    setSession: function (authenticationResult) {
        window.localStorage.setItem("token", authenticationResult.token);
        window.localStorage.setItem("expireAt", authenticationResult.expireAt);
        window.localStorage.setItem("refreshToken", authenticationResult.refreshToken);
        window.localStorage.setItem("userId", authenticationResult.userId);
    },
    getToken: function () {
        return window.localStorage.getItem("token");
    },
    isAuthenticated: function () {
        var token = window.localStorage.getItem("token");
        if (!token) {
            return false;
        }
        var expireAt = window.localStorage.getItem("expireAt");
        let diff = differenceInMilliseconds(parseISO(expireAt), new Date());
        if (diff < 0) {
            return false;
        }
        return true;
    },
    checkAndGetToken: function (axios) {
        var token = this.getToken();
        var expireAt = window.localStorage.getItem("expireAt");
        if (!expireAt) {
            return token;
        }

        let diff = differenceInSeconds(parseISO(expireAt), new Date());
        if (diff < 30 && diff > 0) {
            let data = {
                userId: window.localStorage.getItem("userId"),
                refreshToken: window.localStorage.getItem("refreshToken")
            };
            axios.post("api/user/refresh", data, { headers: { "Authorization": "Bearer " + token } })
                .then(response => {
                    this.setSession(response.data);
                    token = response.data.token;
                }).catch(error => { })
        }
        return token;
    },
    logOut: function () {
        // window.localStorage.clear();
        window.localStorage.removeItem("expireAt");
        window.localStorage.removeItem("token");
        window.localStorage.removeItem("refreshToken");
        window.localStorage.removeItem("userId");
    }
}