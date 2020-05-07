function F=getPhase(u,v,Mu,Mv,Um,Vm)
[p q]=ind2sub([Mu Mv],1:Mu*Mv);
F=2*j*pi*[p' q']*[u;v];
end
