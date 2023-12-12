// Libs
import React, { Component } from 'react';
import axios from "axios";

// Styles
import '../../assets/styles/reset.css';
import '../../assets/styles/pages/camera.css';

// Components
import Menu from '../../components/Menu';

// Images
import movimentation from '../../assets/images/camera-movimentation-icon.svg';
import length_icon from '../../assets/images/camera-length-icon.svg';
import updown_icon from '../../assets/images/camera-up-down-icon.svg';
import leftright_icon from '../../assets/images/camera-left-right-icon.svg';
import image_frame from '../../assets/images/temporary/camera-image-frame.png';
import reload_icon from '../../assets/images/camera-reload-icon.svg';

// Movimentação da linha arrastando com o mouse:

function moveLineOne(){
    const dragLine = document.querySelector(".camera-content-image-line-one-background");
    const html = document.querySelector("html");

    const drag = (e) => {
        dragLine.style.top = e.pageY + "px";
        dragLine.style.left = e.pageX + "px";
    }

    dragLine.addEventListener("mousedown", () => {
        window.addEventListener("mousemove", drag);
    })

    window.addEventListener("mouseleave", () => {
        window.removeEventListener("mousemove", drag)
    })

    window.addEventListener("click", () => {
        html.style.draggable = "false";
        window.removeEventListener("mousemove", drag)
    })
}

function moveLineTwo(){
    const dragLine = document.querySelector(".camera-content-image-line-two-background");
    
    const drag = (e) => {
        dragLine.style.top = e.pageY + "px";
        dragLine.style.left = e.pageX + "px";
    }

    dragLine.addEventListener("mousedown", () => {
        window.addEventListener("mousemove", drag);
    })

    window.addEventListener("mouseleave", () => {
        window.removeEventListener("mousemove", drag)
    })

    window.addEventListener("click", () => {
        window.removeEventListener("mousemove", drag)
    })
}

function clickedLineOne(){
    const lineOne = document.querySelector(".camera-content-image-line-one");
    const lineTwo = document.querySelector(".camera-content-image-line-two");

    window.addEventListener("click", () => {
        lineTwo.classList.remove("active");
        lineOne.classList.add("active");
    })
}

function clickedLineTwo(){
    const lineOne = document.querySelector(".camera-content-image-line-one");
    const lineTwo = document.querySelector(".camera-content-image-line-two");

    window.addEventListener("click", () => {
        lineOne.classList.remove("active");
        lineTwo.classList.add("active");
    })
}

function hoverNewFrame(){
    const background = document.querySelector(".camera-content-image-opacity-background");
    const frame = document.querySelector(".camera-content-image-new-frame");

    background.addEventListener("mouseover", () => {
        frame.classList.toggle("active");
    })

    background.addEventListener("mouseleave", () => {
        frame.classList.toggle("active");
    })

    frame.addEventListener("mouseover", () => {
        frame.classList.add("active");
    })

    frame.addEventListener("mouseleave", () => {
        frame.classList.remove("active");
    })
}


class Camera extends Component {
    constructor(props){
        super(props);
        this.state = {
            example : ''
        }
    }

    componentDidMount(){
        moveLineOne();
        moveLineTwo();
        hoverNewFrame();

        var lineOne = document.getElementById("lineTwo");
        var style = lineOne.currentStyle || window.getComputedStyle(lineOne);

        console.log("Line Two: Top=" + style.top + " and Left=" + style.left)
    }

    render() {
        return(
            <>
                <Menu>
                    <div className="camera-background">
                        <div className="camera-title">
                            <h2>Altere a sua área de risco</h2>
                        </div>

                        <div className="camera-content-background">
                            <div className="camera-content-inputs">
                                <div className="camera-content-inputs-form">
                                    <div className="camera-content-inputs-opacity">
                                        <p className="camera-content-inputs-title">Escurecer fundo %</p>
                                        <input type="number" min="10" max="90" maxLength="1" placeholder="70% mais escuro" />
                                    </div>

                                    <div className="camera-content-inputs-lines">
                                        <div className="camera-content-inputs-lines-title">
                                            <p className="camera-content-inputs-title">Linhas</p>
                                            <img src={movimentation} alt="Ícone de movimentação" draggable="false" />
                                        </div>
                                        <div className="camera-content-inputs-lines-main">
                                            <div className="camera-content-inputs-lines-btn"><img src={length_icon} alt="Ícone de comprimento" draggable="false" /></div>
                                            <input type="number" placeholder="1000px de largura" />
                                        </div>

                                        <div className="camera-content-inputs-lines-main">
                                            <div className="camera-content-inputs-lines-btn"><img src={updown_icon} alt="Ícone de comprimento" draggable="false" /></div>
                                            <input type="number" placeholder="1000px de altura" />
                                        </div>

                                        <div className="camera-content-inputs-lines-main">
                                            <div className="camera-content-inputs-lines-btn"><img src={leftright_icon} alt="Ícone de comprimento" draggable="false" /></div>
                                            <input type="number" placeholder="1000px de distância" />
                                        </div>
                                    </div>
                                </div>
                                <div className="camera-content-inputs-form-btn">
                                    <button>Salvar alterações</button>
                                    <button disabled>Cancelar alterações</button>
                                </div>
                            </div>

                            <div className="camera-content-image-background">
                                <div className="camera-content-image-dashed-border">
                                    
                                    <div className="camera-content-image-frame-main">
                                        <div className="camera-content-image-new-frame">
                                            <div className="camera-content-image-new-frame-reload">
                                                <img src={reload_icon} alt="Ícone de reload" draggable="false" />
                                            </div>
                                            <div className="camera-content-image-new-frame-desc">
                                                <p>Capturar outro frame</p>
                                            </div>
                                        </div>

                                        <div id="lineOne" onClick={clickedLineOne} className="camera-content-image-line-one-background">
                                            <div className="camera-content-image-line-one active"></div>
                                        </div>

                                        <div id="lineTwo" onClick={clickedLineTwo} className="camera-content-image-line-two-background">
                                            <div className="camera-content-image-line-two"></div>
                                        </div>

                                        <div className="camera-content-image-opacity-background"></div>
                                        <img src={image_frame} alt="Imagem da câmera" draggable="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </Menu>
            </>
        )
    }
}

export default Camera;