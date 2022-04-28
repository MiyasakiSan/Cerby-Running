mergeInto(LibraryManager.library, {
    PlayerScore: function (score){
        window.dispatchReactUnityEvent("PlayerScore",score);
    }
});